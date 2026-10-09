function printname(){
    let name = document.getElementById("inp").value;
    let height = parseFloat(document.getElementById("height").value);
    let weight = parseFloat(document.getElementById("weight").value);
    let age = document.getElementById("age").value;

    if (!name || isNaN(height) || isNaN(weight) || height <= 0 || weight <= 0) {
        alert("Please enter a valid name, height, and weight.");
        return;
    }

    // If height is entered in cm (e.g. 175), convert to meters. If entered in meters (e.g. 1.75), leave as is.
    if (height > 3) {
        height = height / 100;
    }

    const numericBmi = weight / (height * height);
    const bmi = numericBmi.toFixed(2);

    let status = "";
    if (numericBmi < 18.5) {
        status = "you are underweight";
    } else if (numericBmi >= 18.5 && numericBmi <= 24.9) {
        status = "you are normal weight";
    } else if (numericBmi >= 25 && numericBmi <= 29.9) {
        status = "you are overweight";
    } else {
        status = "you are obese";
    }

    const params = new URLSearchParams();
    params.append('name', name);
    params.append('bmi', bmi);
    params.append('status', status);
    
    // Pass data securely through the URL parameters
    window.location.href = "res.html?" + params.toString();
}




