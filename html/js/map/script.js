let list=new Array();
function func(){
let name = document.getElementById('ip1').value;
let age = document.getElementById('ip2').value;
    list.push({
        "name":name,
        "age":age
    })
    let lastItem = list[list.length - 1];
    console.log(list);
    document.getElementById("display").innerHTML = lastItem.name + "  -  " + lastItem.age;
}
