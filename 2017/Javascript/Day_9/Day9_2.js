const fs = require("fs");

/* Read input */
let inpFile = "./input";
let input = fs.readFileSync(inpFile).toString();

/* Define helper functions */
const handleGarbage = (action) => {
    let char = action.input[action.i];

    while (char != ">") {
        if (char === "!") { 
            action.i += 2;
         } else {
            action.i++;
            action.numGarbage++;
         }

         char = action.input[action.i];
    }
}

const doNothing = (action) => {
    action.i++;
}

const action = {
    i: 0,
    level: 0,
    score: 0,
    numGarbage: 0,
    input,
    handleGarbage,
    doNothing,
    "{": (action) => { action.level++; action.i++; },
    "}": (action) => { action.score += action.level; action.level--; action.i++ },
    "<": (action) => { action.i++; action.handleGarbage(action) }
}

/* Parse input */
while (action.i < action.input.length) {
    let char = action.input[action.i];

    if (action.hasOwnProperty(char)) {
        action[char](action);
    } else {
        action.doNothing(action);
    }
}

console.log("Number of garbage characters: " + action.numGarbage);
