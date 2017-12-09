const fs = require("fs");

let parseInpLine = (line) => {
    let childNames = [];
    if (line.includes("->")) {
        childNames = line.split("->")[1]
                         .split(",").map(name => name.trim());
    }

    let words = [];  
    const weightRegex = /\(([^)]+)\)/;        
    words.push(line.substr(0, line.indexOf(" "))); // Program name
    words.push(Number(weightRegex.exec(line)[1])); // Program weight
    words.push(childNames);                        // Child program names

    return words;
}

let initializePrograms = (inpLines) => {
    let programs = {};
    inpLines.forEach(line => {
        const inpWords = parseInpLine(line);
        let program = {
            name: inpWords[0],
            weight: inpWords[1],
            childNames: inpWords[2]
        }
        programs[program.name] = program;
    });
    return programs;
}

let addChildren = (programs) => {
    Object.entries(programs).forEach(([name, info]) => {
        info.childPrograms = [];
        info.childNames.forEach(childName => {
            info.childPrograms.push(programs[childName]);
        });
    })
}

let addParent = (programs) => {
    Object.entries(programs).forEach(([name, info]) => {
        info.childPrograms.forEach(childProgram => {
            childProgram.parent = info;
        })
    }); 
}

let findRootProgram = (programs) => {
    let rootProgram = {};
    Object.entries(programs).forEach(([name, info]) => {
        if (info.parent === undefined) {
            rootProgram = info;
        }
    }); 
    return rootProgram;
}

const inpFile = "./input";
let inpLines = fs.readFileSync(inpFile).toString().split("\n");

let programs = initializePrograms(inpLines);
addChildren(programs);
addParent(programs);
let rootProgram = findRootProgram(programs);

console.log(rootProgram);
