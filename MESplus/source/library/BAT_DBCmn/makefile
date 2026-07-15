#### Name of created component ####
LIB_NAME := libBAT_DBCmn
TARGET   := ${LIB_NAME}.so.1.0.0

#### Get options depending on OS and platform ####
include ../../zBuild/makefile.cmm 

##### Include Definitions #####
CC_LIB_INC      = ${CC_LIB_PATH}/include
PROC_INC        = include="${CC_LIB_INC}" include="${ORACLE_INC}" include="${MES_DBINC}"
CC_INC	        = -I${ORACLE_INC} -I${MES_DBINC}

##### Preprocessor Definitions #####
PROC_DEFINE     = define="_ALM" define="_BOM" define="_EDC" define="_FMB" define="_INV" define="_ORD" define="_POP" define="_QCM" define="_RAS" define="_RCP" define="_RTD" define="_SPC" define="_WIP" define="_CRR" define="_TOOL"

##### PROC Compile Options #####
PROCFLAGS       = ${_PROCFLAGS} ${PROC_INC} ${PROC_DEFINE}

##### CC Compile Options #####
CFLAGS          = -fPIC -c ${_DEB} ${_ARC} ${_OPT} ${_OPTDB} ${CC_INC} ${MES_DEFINES}

PROCSOURCE = BDB_common.pc \
	BDB_bin_ooc_calc.pc \
	BDB_mwipbingrd.pc \
	BDB_mwipbinunt.pc \
	BDB_mwiplotsts.pc \
	BDB_mwipqtmdef.pc
	

OBJS = ${PROCSOURCE:.pc=.o}

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

