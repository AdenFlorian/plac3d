const express = require('express')
const app = express()
const axios = require('axios')

app.get('/', function (req, res) {

    console.log("Request received from " + req.headers['x-real-ip'] + " at " + new Date())
    //console.log("Request headers:" + JSON.stringify(req.headers))
    
    axios.get('https://www.reddit.com/api/place/board-bitmap', {
        responseType: 'arraybuffer'
    }).then(function (response) {
        console.log("reddit response.data.length: " + response.data.length);
        //console.log("reddit response.status: " + response.status);
        res.send(response.data);
    })
})

app.listen(3000, function () {
    console.log('Example app listening on port 3000!')
})
