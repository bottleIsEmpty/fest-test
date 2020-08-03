import React, {useEffect, useState} from 'react';
import './App.css';
import {Form} from "./components/Form";

function App() {
    let [countries, setCountries] = useState([]);
    let [info, setInfo] = useState("");

    useEffect(() => {
       fetch("https://restcountries.eu/rest/v2/all?fields=alpha2Code;name")
           .then(res => res.json())
           .then(countries => setCountries(countries))
    }, []);

    const formSubmitted =

    return (
        <div className="App">
            <Form countries={countries} onSubmit={getWeatherForecast}/>
        </div>
    );
}

export default App;
