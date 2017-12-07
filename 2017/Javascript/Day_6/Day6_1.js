const fs = require("fs");

const inpFile = "./input";
let blocks = fs.readFileSync(inpFile).toString().split(" ").map(Number);

/* Identify first state */
let bankState = blocks.join('');

/* Identify remaining states */
let states = {};
let numSteps = 0;
while (states[bankState] != 1) {
    states[bankState] = ++states[bankState] || 1;
    
    /* Find index of largest num blocks, get num blocks and set val to 0 */
    let largestNum = Math.max(...blocks);
    let indexLargestNum = blocks.indexOf(largestNum);
    blocks[indexLargestNum] = 0;

    /* Distribute blocks  */
    let index = indexLargestNum + 1;
    while (largestNum > 0) {
        blocks[(index++) % blocks.length]++;
        largestNum--;
    }

    bankState = blocks.join('');
    numSteps++;
}

console.log("Number of steps: " + numSteps);
