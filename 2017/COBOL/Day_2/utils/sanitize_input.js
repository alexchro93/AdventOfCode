/* Probably not the best way to do this but... oh well. */
const fs = require('fs');
const readLine = require('readline');

const inpFile = './DATA';
const outFile = './INPUT.DAT';

/* Format input for COBOL program */
const lineReader = readLine.createInterface({
    input: fs.createReadStream(inpFile)
});

lineReader.on('line', (line) => {
    const numbers = line.split(',');
    let lineToWrite = '';
    numbers.forEach(element => {
        const numZeros = 4 - element.length;
        lineToWrite += Array(numZeros + 1).join('0') + element;
    });
    fs.appendFileSync(outFile, lineToWrite + '\n', { encoding: 'utf-8' });
});
