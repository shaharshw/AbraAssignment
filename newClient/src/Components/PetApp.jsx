import { Route, BrowserRouter, Routes } from 'react-router-dom';
import Home from './Home.jsx'


export default function PetApp() {
    return (
        <div className='PetApp'>
            <BrowserRouter>
                <Routes>
                    <Route path='/' element={<Home />}></Route>
                </Routes>
            </BrowserRouter>
        </div>
    );
}