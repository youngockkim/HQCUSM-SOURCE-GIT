/* MTSTDEVMBR : Test for development data member */
CREATE TABLE MTSTDEVMBR
(
    TEST_ID                     VARCHAR2(50)     DEFAULT(' ')    NOT NULL,
    TEST_INT                    NUMBER(6)        DEFAULT(NULL),
    TEST_FLOAT                  NUMBER(10,3)     DEFAULT(NULL),
    TEST_DOUBLE                 NUMBER(20,6)     DEFAULT(NULL),
    TEST_LONG                   NUMBER(15)       DEFAULT(NULL),
    TEST_CHAR                   CHAR(1)          DEFAULT(NULL),
    TEST_STRING                 VARCHAR2(100)    DEFAULT(NULL),
    TEST_BOOL                   CHAR(1)          DEFAULT(NULL),
    TEST_BINARY                 CHAR(1)          DEFAULT(NULL),
    TEST_DATETIME               DATE             DEFAULT(NULL)
) TABLESPACE MESPLUS_DATA_TS;

ALTER TABLE MTSTDEVMBR 
ADD CONSTRAINT MTSTDEVMBR_PK PRIMARY KEY
(
    TEST_ID
) USING INDEX TABLESPACE MESPLUS_IDX_TS;



