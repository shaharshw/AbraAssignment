import { useState } from 'react';

import { getPets, createPet } from '../api/api.js'


export default function Home() {
    const [name, setName] = useState("");
    const [type, setType] = useState("");
    const [color, setColor] = useState("");
    const [age, setAge] = useState(0);
    const [Success, setSuccess] = useState(flase);

    const handleSubmit = async (e) => {
        const response = createPet(e);
    }

    const handleClick = async (e) => {
        const pets = getPets();

    }

    return (
        <div>

            <button onClick={handleClick}>Pets</button>
            <h1>Add a new Pet</h1>
            {Success && <div><p>The pet add to DB</p></div>}
            <form>
                <label>Name</label>
                <input
                    type="text"
                    name="name"
                    value={name}
                    onChange={(e) =>
                        setName(e.target.value)
                    }
                    placeholder="Enter Name"
                    required
                />

                <label>Color</label>
                <input
                    type="text"
                    name="color"
                    value={color}
                    onChange={(e) =>
                        setColor(e.target.value)
                    }
                    placeholder="Enter color"
                    required
                />

                <label>Age</label>
                <input
                    type="text"
                    name="age"
                    value={age}
                    onChange={(e) =>
                        setAge(e.target.value)
                    }
                    placeholder="Enter Age"
                    required
                />

                <label>Type</label>
                <select value={type}
                    onChange={(e) => setType(e.target.value)}>
                    <option value="">Select Type</option>
                    <option value="dog">Dog</option>
                    <option value="cat">Cat</option>
                    <option value="horse">Horse</option>
                    <option value="other">Other</option>
                </select>

                <button type="submit" onClick={handleSubmit}>Add Pet</button>
            </form>
        </div>
    );
}