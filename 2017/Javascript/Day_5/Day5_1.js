const fs = require("fs");

/* Read input file into array */
const inpFile = "./input";
const inpData = fs.readFileSync(inpFile).toString().split("\n").map(Number);

let numSteps = 0;
let index = 0;
console.time("Find exit");
while (index >= 0 && index <= (inpData.length - 1)) {
    index += inpData[index]++;
    numSteps++;
}
console.timeEnd("Find exit");

console.log("Number of steps to exit:", numSteps);
