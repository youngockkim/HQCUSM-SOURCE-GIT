#ifndef __RPT_Q_CON_N_H
#define __RPT_Q_CON_N_H

struct DB_Q_COND_N_TAG {
    char FROM_DATE[9];
    char TO_DATE[9];
    char FROM_TIME[15];
    char TO_TIME[15];
    char MAT_TYPE[21];
    char MAT_GRP[21];
    char RES_ID[21];
    char OPER[11];
    char SPC_SUMMARY_KEY[13];
    int FROM_SEQ;
    int TO_SEQ;
    int PRIO_LEVEL;
    char PRIO_KEY[21];
    char KEY_VALUE_1[31];
    char KEY_VALUE_2[31];
};

extern struct DB_Q_COND_N_TAG DB_Q_COND_N;

#endif
