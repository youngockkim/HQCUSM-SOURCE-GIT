#### Name of created component ####
LIB_NAME := MES_UserWIP
TARGET   := ${LIB_NAME}.so.1.1.5

#### Get options depending on OS and platform ####
include ../../zBuild/makefile.cmm 

##### Libraries #####
LIB     = ${MES_SLC_LIB}

##### Include files #####
INCLUDE = -I${MES_INC} -I${MES_DBINC} -I${ORACLE_INC}

##### Compile options #####
CFLAGS  = -fPIC -c ${_DEB} ${_ARC} ${_OPT} ${_OPTDB} ${INCLUDE} ${MES_DEFINES}


##### Object files #####
OBJS = UWIPAddService.o \
	UWIP_summary_temp_lot.o \
	UWIP_generate_sublot_id.o \
	UWIP_future_action_custom_action.o \
	UWIP_future_action_custom_condition.o \
	UWIP_adapt_lot.o \
	UWIP_end_lot.o \
	UWIP_start_lot.o \
	UWIP_update_factory.o \
	UWIP_view_hold_lot_list.o


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

