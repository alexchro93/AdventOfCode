const fs = require("fs");

// Generate number list
const list_length = 256;
let list = [list_length];
for (let i = 0; i < list_length; i++) {
    list[i] = i;
}

//  Get input
let inpFile = "./input";
let lengths = fs.readFileSync(inpFile).toString().split(",").map(item => Number(item));

// Do hash algorithm
let pos = 0;
let skip = 0;
lengths.forEach(length => {
    if (length != 0) {
        // Identify sub array start and end positions.
        let start = pos % list_length;
        let end = (pos + length - 1) % list_length;

        // Reverse elements
        if (start < end ) {
            list = [
                ...list.slice(0, start),
                ...list.slice(start, end + 1).reverse(),
                ...list.slice(end + 1)
            ]
        } else if (start > end) {
            let tempList = [
                ...list.slice(start),
                ...list.slice(0, end + 1)
            ].reverse();
        
            let mid = list_length - start;        
            list = [
                ...tempList.slice(mid),
                ...list.slice(end + 1, start),
                ...tempList.slice(0, mid)
            ];
        }
    }

    // Find new position and increment skip
    pos = pos + length + skip;
    skip++;
});

console.log("Answer: " + list[0] * list[1]);
