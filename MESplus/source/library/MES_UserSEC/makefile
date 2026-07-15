#### Name of created component ####
LIB_NAME := MES_UserSEC
TARGET   := ${LIB_NAME}.so.1.1.0

#### Get options depending on OS and platform ####
include ../../zBuild/makefile.cmm 

##### Libraries #####
LIB     = ${MES_SLC_LIB}

##### Include files #####
INCLUDE = -I${MES_INC} -I${MES_DBINC} -I${ORACLE_INC}

##### Compile options #####
CFLAGS  = -fPIC -c ${_DEB} ${_ARC} ${_OPT} ${_OPTDB} ${INCLUDE} ${MES_DEFINES}


##### Object files #####
OBJS = USECAddService.o \
	USEC_login_ext.o \
	USEC_update_user_ext.o \
	USEC_view_function_list.o


###### Build Rules ######
default : ${TARGET}

build : clean ${TARGET}


###### Compile all source files ######
.c.o :
	${CC} ${CFLAGS} $?

###### Make a library ######
${TARGET} : ${OBJS}
	${CC} -shared -Wl,-soname,${LIB_NAME}.so -o $@ ${OBJS} ${LIB}
	mv -f ${TARGET} ${MES_HOME}/lib/.
	cp -f *.h ${MES_INC}/.

###### Remove all object files ######
clean :
	rm -f ${OBJS}

