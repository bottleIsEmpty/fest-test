import React, {useEffect, useState} from 'react';
import './App.css';
import {Form} from "./components/Form";
import {ResultInfo} from "./components/ResultInfo";

function App() {
    let [countries, setCountries] = useState([]);
    let [info, setInfo] = useState("");

    useEffect(() => {
       fetch("https://restcountries.eu/rest/v2/all?fields=alpha2Code;name")
           .then(res => res.json())
           .then(countries => setCountries(countries))
    }, []);

    const getWeatherForecast = (cityData) => {
        setInfo("Loading...");

        fetch(`https://localhost:5001/api/CityInfo?ZipCode=${cityData.zipCode}&CountryCode=${cityData.country}`)
            .then(res => {
                if (!res.ok) {
                    throw new Error();
                }
                return res.text()
            })
            .then(data => setInfo(data))
            .catch(() => setInfo("Something went wrong... Try again later or check the input values."))
    }

    return (
        <div className="App">
            <h1>City info fetcher</h1>
            <h5>Insert ZIP-Code, select the country name and press "Get Info!" (e.g. '101000', 'Russian Federation')</h5>
            <Form countries={countries} onSubmit={getWeatherForecast}/>
            {info ? <ResultInfo info={info}/> : null}
        </div>
    );
}

export default App;
