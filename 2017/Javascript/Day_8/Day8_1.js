const fs = require("fs");

/*
 * Functions to identify action
 */
const increment = (val, amt) => {
    return val + amt;
}

const decrement = (val, amt) => {
    return val - amt;
}

const identifyAction = (actionString) => {
    let add = "inc";

    switch (actionString) {
        case "inc":
            return increment;
        case "dec":
            return decrement;
        default: 
            throw new Error("Could not identify action.");
    }
}

/*
 * Functions to identify condition
 */ 

 const greaterThan = (val, amt) => {
     return val > amt;
 }

 const lessThan = (val, amt) => {
    return val < amt;
}

const greaterThanEqual = (val, amt) => {
    return val >= amt;
}

const lessThanEqual = (val, amt) => {
    return val <= amt;
}

const equal = (val, amt) => {
    return val === amt;
}

const notEqual = (val, amt) => {
    return val != amt;
}

const identifyCond = (condString) => {
    switch (condString) {
        case ">":
            return greaterThan;
        case "<":
            return lessThan;
        case ">=":
            return greaterThanEqual;
        case "<=":
            return lessThanEqual;
        case "==":
            return equal;
        case "!=":
            return notEqual;
        default:
            throw new Error("Could not identify condition");
    }
}

// Read input
const inpFile = "./input";
let inpLines = fs.readFileSync(inpFile).toString().split("\n");

// Initialize registers
let registers = {};
inpLines.forEach(line => {
    let register = line.substr(0, line.indexOf(" "));
    registers[register] = 0;
});

// Decode and execute instruction
inpLines.forEach(line => {
    // Decode Instruction
    let words = line.split(" ");
    let register = words[0];
    let action = identifyAction(words[1]);
    let cond = identifyCond(words[5]);

    // Execute Instruction
    let registerVal = registers[register];
    if (cond(registers[words[4]], Number(words[6]))) {    
       let newRegisterVal = action(registerVal, Number(words[2]));
       registers[register] = newRegisterVal;       
    }
});

// Find max value
let maxValue = 0;
Object.entries(registers).forEach(([name, value]) => {
    if (value > maxValue) {
        maxValue = value;
        console.log(name, value);
    }
})