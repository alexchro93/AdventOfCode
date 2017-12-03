*> Advent of Code 2017 Day 2 Challenge 1
IDENTIFICATION DIVISION.
PROGRAM-ID. DAY2_1.

ENVIRONMENT DIVISION.
INPUT-OUTPUT SECTION.
FILE-CONTROL.
SELECT IN-FILE 
    ASSIGN TO './utils/INPUT.DAT'
    ORGANIZATION IS LINE SEQUENTIAL.

DATA DIVISION.
    FILE SECTION.
        FD IN-FILE.
        01 IN-ROW PIC A(64).
    WORKING-STORAGE SECTION.
        01 WS-NUM-ROWS      PIC 9(2) VALUE 16.
        01 WS-ROW           PIC 9(2).
        01 WS-COL           PIC 9(2).
        01 WS-ANS           PIC 9(10).
        01 WS-MAX           PIC 9(4) VALUE 0000.
        01 WS-MIN           PIC 9(4) VALUE 9999.
        01 WS-CURR-DIGIT    PIC 9(4) VALUE 0000.
        01 WS-DIFFERENCE    PIC 9(6) VALUE 0000.
        01 WS-INPUT-TABLE.
            05 WS-INPUT-ROW OCCURS 16 TIMES.
                10 WS-INPUT-DIGIT OCCURS 16 TIMES PIC 9(4).

PROCEDURE DIVISION.
100-MAIN.
    PERFORM 200-CREATE-TABLE THRU 200-CREATE-TABLE-EXIT
    PERFORM 300-FIND-ANS THRU 300-FIND-ANS-EXIT
    DISPLAY WS-ANS
    STOP RUN.

200-CREATE-TABLE.
    OPEN INPUT IN-FILE
        PERFORM VARYING WS-ROW FROM 1 BY 1 UNTIL WS-ROW > WS-NUM-ROWS
            READ IN-FILE
                NOT AT END MOVE IN-ROW TO WS-INPUT-ROW(WS-ROW)
            END-READ
        END-PERFORM.
    CLOSE IN-FILE.

200-CREATE-TABLE-EXIT.
    EXIT.

300-FIND-ANS.
    PERFORM VARYING WS-ROW FROM 1 BY 1 UNTIL WS-ROW > WS-NUM-ROWS
        PERFORM VARYING WS-COL FROM 1 BY 1 UNTIL WS-COL > WS-NUM-ROWS
            MOVE WS-INPUT-DIGIT(WS-ROW, WS-COL) TO WS-CURR-DIGIT
            IF WS-CURR-DIGIT IS GREATER THAN WS-MAX
                MOVE WS-CURR-DIGIT TO WS-MAX
            ELSE IF WS-CURR-DIGIT IS LESS THAN WS-MIN
                MOVE WS-CURR-DIGIT TO WS-MIN
            END-IF
        END-PERFORM

        SUBTRACT WS-MAX FROM WS-MIN GIVING WS-DIFFERENCE
        ADD WS-DIFFERENCE TO WS-ANS

        SET WS-MAX TO 0000
        SET WS-MIN TO 9999
    END-PERFORM.  

300-FIND-ANS-EXIT.
    EXIT.
