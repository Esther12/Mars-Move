var express  = require("express");
var path = require("path");
var apiRoutes = require("./app/routing/apiRoutes");
var htmlRoutes = require("./app/routing/htmlRoutes");

var app = express();

var PORT = process.env.PORT || 3000;


app.use(express.urlencoded({ extended: true }));
app.use(express.json());

app.use("/signup",apiRoutes);
app.use("/signup",htmlRoutes);

app.listen(PORT, function() {
    console.log("App listening on PORT: " + PORT);
    });