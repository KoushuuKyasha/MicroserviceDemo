'use strict';

let express = require('express')
let jwt = require('express-jwt');
let jwksClient = require('jwks-rsa');
let cors = require('cors');

const app = express();
app.use(cors());

const issuer = 'http://msdemo.henryhc.net:5001';

// define authentication middleware
const auth = jwt({
    // validate the audience & issuer from received token vs JWKS endpoint
    audience: 'hello_api',
    issuer: issuer
});

app.get('/api/message',
    auth,
    (req, res) => {
        res.contentType('text/plain');
        let now = new Date();
        res.send('Hello from Node.js Service at ' + now);
    });

app.listen(80, '0.0.0.0', () => console.log('Listening on http://localhost:80'));