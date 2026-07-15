#### Name of created component ####
LIB_NAME := MES_UserRAS
TARGET   := ${LIB_NAME}.so.1.1.3

#### Get options depending on OS and platform ####
include ../../zBuild/makefile.cmm 

##### Libraries #####
LIB     = ${MES_SLC_LIB}

##### Include files #####
INCLUDE = -I${MES_INC} -I${MES_DBINC} -I${ORACLE_INC}

##### Compile options #####
CFLAGS  = -fPIC -c ${_DEB} ${_ARC} ${_OPT} ${_OPTDB} ${INCLUDE} ${MES_DEFINES}


##### Object files #####
OBJS = URASAddService.o \
	URAS_summary_temp_res.o \
	URAS_summary_temp_carrier.o \
    URAS_summary_temp_port.o \
	URAS_resource_event.o \
	URAS_update_carrier.o \
	URAS_view_carrier.o


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

