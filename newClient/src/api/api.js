import axios from "axios";

const API_URL = 'https://localhost:7066/api/pet'; 


export const getPets = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};


export const createPet = async (pet) => {
    const response = await axios.post(API_URL, user);
    return response.data;
};