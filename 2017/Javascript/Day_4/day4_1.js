const fs = require("fs");

/* Read input file into array */
const inpFile = "./input";
const inpData = fs.readFileSync(inpFile).toString().split("\n");

let numValid = inpData.length;
inpData.forEach(line => {
    let isValid = true;    
    const sortedLine = line.split(" ").sort();
    for (let i = 0; (i < sortedLine.length - 1) && isValid; i++) {
        if (sortedLine[i + 1] === sortedLine[i]) {
            isValid = false;
            numValid--;
        }
    }
});

console.log("Num valid lines: " + numValid);
