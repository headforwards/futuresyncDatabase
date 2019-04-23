// rename this file to firebase.js and update the below api keys

import app from 'firebase/app';

const config = {
    apiKey: "<APIKEY>",
    authDomain: "<AUTHDOMAIN>",
    databaseURL: "<DATABASEURL>",
    projectId: "<PROJECTID>",
    storageBucket: "<STORAGEBUCKET>",
    messagingSenderId: "<MESSAGESENDERID>"
};

class Firebase {
    constructor() {
        app.initializeApp(config);
    }
}

export default Firebase;