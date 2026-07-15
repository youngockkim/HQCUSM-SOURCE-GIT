#### Name of created component ####
LIB_NAME := libRPT_DBCmn
TARGET   := ${LIB_NAME}.so.1.1.6

#### Get options depending on OS and platform ####
include ../../zBuild/makefile.cmm 

##### Include Definitions #####
CC_LIB_INC      = ${CC_LIB_PATH}/include
PROC_INC        = include="${CC_LIB_INC}" include="${ORACLE_INC}" include="${ORACLE_OCI_INC}" include="${MES_DBINC}"
CC_INC	        = -I${ORACLE_INC} -I${ORACLE_OCI_INC} -I${MES_DBINC}

##### Preprocessor Definitions #####
PROC_DEFINE     = define="_ALM" define="_BOM" define="_EDC" define="_FMB" define="_INV" define="_ORD" define="_POP" define="_QCM" define="_RAS" define="_RCP" define="_RTD" define="_SPC" define="_WIP" define="_CRR" define="_TOOL"

##### PROC Compile Options #####
PROCFLAGS       = PARSE=PARTIAL ${PROC_INC} ${PROC_DEFINE}

##### CC Compile Options #####
CFLAGS          = -fPIC -c ${CC_INC} ${MES_DEFINES}


PROCSOURCE = RPT_common.pc \
	RPT_mbasglbdef.pc     \
	RPT_medclotdat.pc     \
	RPT_medcresdat.pc     \
	RPT_mgcmtbldat.pc     \
	RPT_mmsgmsgdef.pc     \
	RPT_mrasresdef.pc     \
	RPT_mrasreshis.pc     \
	RPT_mrasreslth.pc     \
	RPT_mrassrslot.pc     \
	RPT_mrassrslth.pc     \
	RPT_mtmpatrhis.pc     \
	RPT_mtmpatrhis_bak.pc \
	RPT_mtmpcrrhis.pc     \
	RPT_mtmpcrrhis_bak.pc \
	RPT_mtmplothis.pc     \
	RPT_mtmplothis_bak.pc \
	RPT_mtmpreshis.pc     \
	RPT_mtmpreshis_bak.pc \
	RPT_mwipcaldef.pc     \
	RPT_mwipcytdef.pc     \
	RPT_mwipfacdef.pc     \
	RPT_mwipflwdef.pc     \
	RPT_mwipflwopr.pc     \
	RPT_mwiplotcvm.pc     \
	RPT_mwiplothis.pc     \
	RPT_mwiplothld.pc     \
	RPT_mwiplotsts.pc     \
	RPT_mwipmatdef.pc     \
	RPT_mwipmatflw.pc     \
	RPT_mwipoprdef.pc     \
	RPT_mwipslthis.pc     \
	RPT_mwipsltlos.pc     \
	RPT_mwipsltsts.pc     \
	RPT_mwiplotdel.pc     \
	RPT_ratrnamhis.pc     \
	RPT_ratrnamsts.pc     \
	RPT_redclotdat.pc     \
	RPT_redcresdat.pc     \
	RPT_rprcprcstp.pc     \
	RPT_rrascrrdef.pc     \
	RPT_rrascrrhis.pc     \
	RPT_rrasresdef.pc     \
	RPT_rrasreshis.pc     \
	RPT_rrasreslth.pc     \
	RPT_rrassrsdef.pc     \
	RPT_rrassrshis.pc     \
	RPT_rrassrslot.pc     \
	RPT_rrassrslth.pc     \
	RPT_rrwkclshis.pc     \
	RPT_rrwklotsts.pc     \
	RPT_rsumfacmov.pc     \
	RPT_rsumlincyc.pc     \
	RPT_rsumlinmov.pc     \
	RPT_rsumprclog.pc     \
	RPT_rsumresmov.pc     \
	RPT_rsumrestmh.pc     \
	RPT_rsumseccyc.pc     \
	RPT_rsumsecmov.pc     \
	RPT_rsumtmplyd.pc     \
	RPT_rsumtmpwct.pc     \
	RPT_rsumtmpwyd.pc     \
	RPT_rsumwipeoh.pc     \
	RPT_rsumwipldr.pc     \
	RPT_rsumwiplth.pc     \
	RPT_rsumwipmov.pc     \
	RPT_rsumwrkcyc.pc     \
	RPT_rsumwrkmov.pc     \
	RPT_rtmpdsmhis.pc     \
	RPT_rwiplotbns.pc     \
	RPT_rwiplotcmb.pc     \
	RPT_rwiplotcvr.pc     \
	RPT_rwiplotdue.pc     \
	RPT_rwiplothis.pc     \
	RPT_rwiplothld.pc     \
	RPT_rwiplotlos.pc     \
	RPT_rwiplotlsm.pc     \
	RPT_rwiplotmrg.pc     \
	RPT_rwiplotrwk.pc     \
	RPT_rwiplotshp.pc     \
	RPT_rwiplotspl.pc     \
	RPT_rwiplotspm.pc     \
	RPT_rwiplotsts.pc     \
	RPT_rwiplottxt.pc     \
	RPT_rwippltsts.pc     \
	RPT_rwipslthis.pc     \
	RPT_rwipsltlos.pc     \
	RPT_rwiplotdel.pc     \
	RPT_rwipsltsts.pc     \
    RPT_mtmppothis.pc     \
    RPT_mtmppothis_bak.pc \
    RPT_rraspotdef.pc     \
    RPT_rraspothis.pc     \
    RPT_rwipcrrlot.pc     \
    RPT_rwipcrrlth.pc     

OBJS    = $(PROCSOURCE:.pc=.o)


default: copy_header ${TARGET} copy

build: clean copy_header ${TARGET} copy

${TARGET}: ${OBJS}
	${CC} -shared -Wl,-soname,${LIB_NAME}.so -o $@ ${OBJS}
	rm -f *.lis tp*

clean:
	rm -f *.a *.o *.lis tp*

copy_header:
	cp -f *.h ${MES_HOME}/inc/dbinc

copy:
	rm -f ${MES_HOME}/lib/${LIB_NAME}.so
	mv -f ${TARGET} ${MES_HOME}/lib
	ln -s ${MES_HOME}/lib/${TARGET} ${MES_HOME}/lib/${LIB_NAME}.so

%.c:%.pc
	proc ${PROCFLAGS} $?

.c.o:
	${CC} ${CFLAGS} $?

