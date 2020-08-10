import React, {useEffect, useState} from 'react';

export const Form = (props) => {
    const [zipCode, setZipCode] = useState(null);
    const [country, setCountry] = useState(null);
    const [disabled, setDisabled] = useState(true);

    useEffect(() => {
        setDisabled(!country || !zipCode);
    }, [zipCode, country])

    const countryElements = props.countries.map(c => <option key={c.alpha2Code} value={c.alpha2Code}>{c.name}</option>)

    const handleSubmit = (event) => {
        event.preventDefault();
        props.onSubmit({country, zipCode});
    }

    return (
        <form onSubmit={handleSubmit}>
            <div className="form-control">
                <label htmlFor="zip">ZIP-Code</label>
                <input type="number"
                       required
                       id="zip"
                       name="zip"
                       onChange={e => setZipCode(e.target.value)}/>
            </div>
            <div className="form-control">
                <label htmlFor="country">Country</label>
                <select name="country"
                        id="country"
                        required
                        onChange={e => setCountry(e.target.value)}>
                    <option value="">Select a country</option>
                    {countryElements}
                </select>
            </div>

            <button type="submit" disabled={disabled}>Get info!</button>
        </form>
    )
}