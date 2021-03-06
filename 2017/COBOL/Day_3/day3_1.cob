*> Advent of Code 2017 Day 3 Challenge 1
IDENTIFICATION DIVISION.
PROGRAM-ID. DAY3_1.

DATA DIVISION.
    WORKING-STORAGE SECTION.
        *> Variables for finding next largest odd square
        01 WS-STARTING-NUM          PIC 9(20) VALUE 277678.
        01 WS-ODD-NUM               PIC 9(20).
        01 WS-ODD-SQUARE            PIC 9(20).
        01 WS-FOUND-SQUARE          PIC A VALUE 'N'.

        *> Variables for finding distance to center
        01 WS-MAX-DIST-TO-CENTER    PIC 9(20).
        01 WS-DIST-TO-CENTER        PIC 9(20).
        01 WS-DIFFERENCE            PIC 9(20).
        01 WS-QUOTIENT              PIC 9(20).
        01 WS-REMAINDER             PIC 9(20).

PROCEDURE DIVISION.
100-MAIN.
    IF WS-STARTING-NUM = 1
        SET WS-DIST-TO-CENTER TO 0
    ELSE
        PERFORM 200-FIND-LARGER-ODD-SQUARE THRU 200-FIND-LARGER-ODD-SQUARE-EXIT
        PERFORM 300-FIND-PATH-TO-CENTER THRU 300-FIND-PATH-TO-CENTER-EXIT
    END-IF
    DISPLAY WS-DIST-TO-CENTER
    STOP RUN.

200-FIND-LARGER-ODD-SQUARE.
    PERFORM VARYING WS-ODD-NUM FROM 1 BY 2 UNTIL WS-FOUND-SQUARE = 'Y'
        MULTIPLY WS-ODD-NUM BY WS-ODD-NUM GIVING WS-ODD-SQUARE
        IF WS-ODD-SQUARE > WS-STARTING-NUM
            MOVE 'Y' TO WS-FOUND-SQUARE
        END-IF
    END-PERFORM

    SUBTRACT 2 FROM WS-ODD-NUM
    SUBTRACT 1 FROM WS-ODD-NUM GIVING WS-MAX-DIST-TO-CENTER.

200-FIND-LARGER-ODD-SQUARE-EXIT.
    EXIT.

300-FIND-PATH-TO-CENTER.
    SUBTRACT WS-STARTING-NUM FROM WS-ODD-SQUARE GIVING WS-DIFFERENCE
    DIVIDE WS-DIFFERENCE BY WS-MAX-DIST-TO-CENTER
        GIVING WS-QUOTIENT REMAINDER WS-REMAINDER
    IF WS-REMAINDER = 0
        SET WS-DIST-TO-CENTER TO WS-MAX-DIST-TO-CENTER
    ELSE
        SUBTRACT WS-REMAINDER FROM WS-MAX-DIST-TO-CENTER GIVING WS-DIST-TO-CENTER
    END-IF.

300-FIND-PATH-TO-CENTER-EXIT.
    EXIT.
