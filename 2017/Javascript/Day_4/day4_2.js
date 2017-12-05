const fs = require("fs");

/* Read input file into array */
const inpFile = "./input";
const inpData = fs.readFileSync(inpFile).toString().split("\n");

let numValid = inpData.length;
inpData.forEach(line => {
    /* First sort individual words */
    let tempLine = line.split(" ");
    for (let i = 0; i < tempLine.length; i++) {
        tempLine[i] = tempLine[i].split('').sort().join('');
    }

    /* Sort line and find duplicate */
    let isValid = true;
    const sortedLine = tempLine.sort();
    for (let i = 0; (i < sortedLine.length - 1) && isValid; i++) {
        if (sortedLine[i + 1] === sortedLine[i]) {
            isValid = false;
            numValid--;
        }
    }
});

console.log("Num valid lines: " + numValid);
