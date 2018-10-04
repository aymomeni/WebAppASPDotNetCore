var x = 0;
var s = "";

alert("Hello Pluralsight");
console.log("Got here. " + document.getElementById('theForm'));

var theForm = document.getElementById('theForm');

var button = document.getElementById('buyButton');
button.addEventListener("click", function () {
    console.log("Buying Item");
});

var productInfo = document.getElementsByClassName("product-props");
//var listItems = productInfo.item[0].children;