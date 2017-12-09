const fs = require("fs");

/*
 * Functions to identify action
 */

const actions = {
    inc: (val, amt) => { return val + amt },
    dec: (val, amt) => { return val - amt }
}

/*
 * Functions to identify condition
 */ 

 const conditions = {
     ">" : (val, amt) => { return val > amt; },
     "<" : (val, amt) => { return val < amt; },
     ">=" : (val, amt) => { return val >= amt; },
     "<=" : (val, amt) => { return val <= amt; },
     "==" : (val, amt) => { return val === amt; },
     "!=" : (val, amt) => { return val != amt; }
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
let maxValue = 0;
inpLines.forEach(line => {
    // Decode Instruction
    let words = line.split(" ");

    // Execute Instruction
    let registerVal = registers[words[0]];
    if (conditions[words[5]](registers[words[4]], Number(words[6]))) {    
       let newRegisterVal = actions[words[1]](registerVal, Number(words[2]));
       registers[words[0]] = newRegisterVal;    
       maxValue = (newRegisterVal > maxValue) ? newRegisterVal : maxValue;        
    }
});

console.log(maxValue);
