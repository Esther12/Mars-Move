var express = require("express");
var path = require("path");
var friendData = require("../data/friends");

var app = express.Router();

app.post("/", function(req,res){
    var newFiendData = req.body;
    console.log(newFiendData);

})

function findTheBest (a,b){
    // Try edit message
    
    a.forEach(function(item, index, arr) {
        // item - current value in the loop
        // index - index for this value in the array
        // arr - reference to analyzed array  
        arr[index] = item - b[index];
    })
    var x=a;
    //in this case we override values in first array
    console.log(a);
    function Diff(num){ 
            if(num < 0){
            diff=num *(-1);
            }else{
            diff=num;
            }
        return diff;
    }
    console.log(x.map(Diff));
    x1 = x.map(Diff);
    var arrSum = arr => arr.reduce((a,b) => a + b, 0);
    return arrSum(x1);  
}

