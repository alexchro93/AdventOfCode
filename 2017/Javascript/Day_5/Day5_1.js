const fs = require("fs");

/* Read input file into array */
const inpFile = "./input";
const inpData = fs.readFileSync(inpFile).toString().split("\n");

let numSteps = 0;
let index = 0;
let exited = false;
while (!exited) {
    index = index + inpData[index]++;

    /* Check to see if index extends bounds of input array */
    if (index < 0 || index > (inpData.length - 1)) {
        exited = true;
    }

    numSteps++;
}

console.log("Number of steps to exit:", numSteps);
