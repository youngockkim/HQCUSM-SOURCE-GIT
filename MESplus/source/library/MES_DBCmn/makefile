#### Name of created component ####
LIB_NAME := libMES_DBCmn
TARGET   := ${LIB_NAME}.so.1.1.20

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

PROCSOURCE = DBC_common.pc \
	DBC_dynamicquery.pc \
	DBC_edccore_join.pc \
	DBC_fmbcore_join.pc \
	DBC_malmmfores.pc \
	DBC_malmmsgdef.pc \
	DBC_malmmsghis.pc \
	DBC_malmrcvdef.pc \
	DBC_matrnamdef.pc \
	DBC_matrnamhis.pc \
	DBC_matrnamsts.pc \
	DBC_mbomlotash.pc \
	DBC_mbomlotass.pc \
	DBC_mbomsetdef.pc \
	DBC_mbomsetmat.pc \
	DBC_mbomsetver.pc \
	DBC_medcchrdef.pc \
	DBC_medccolchr.pc \
	DBC_medccoldef.pc \
	DBC_medccolunt.pc \
	DBC_medccolver.pc \
	DBC_medclotdat.pc \
	DBC_medcresdat.pc \
	DBC_mfmbenvdef.pc \
	DBC_mfmbevtclr.pc \
	DBC_mfmbfaclyt.pc \
	DBC_mfmbgrpusr.pc \
	DBC_mfmbresimg.pc \
	DBC_mfmbresloc.pc \
	DBC_mfmbudrdef.pc \
	DBC_mfmbudrloc.pc \
	DBC_mgcmtbldat.pc \
	DBC_mgcmtbldef.pc \
	DBC_minvmathis.pc \
	DBC_minvmatsts.pc \
	DBC_minvsrlsts.pc \
	DBC_mmsgmsgdef.pc \
	DBC_mpoplbldef.pc \
	DBC_mpoplbldgn.pc \
	DBC_mpoplblimg.pc \
	DBC_mpoplotprh.pc \
	DBC_mpopmatlbl.pc \
	DBC_mqcmbatdft.pc \
	DBC_mqcmbathis.pc \
	DBC_mqcmbatisp.pc \
	DBC_mqcmbatsts.pc \
	DBC_mqcmitmdef.pc \
	DBC_mqcmitmdft.pc \
	DBC_mqcmitmisp.pc \
	DBC_mqcmitmsts.pc \
	DBC_mqcmmatdef.pc \
	DBC_mqcmsetdef.pc \
	DBC_mqcmsetitm.pc \
	DBC_mqcmsetver.pc \
	DBC_mqcmsmpdef.pc \
	DBC_mrascgrrel.pc \
	DBC_mrascrrdef.pc \
	DBC_mrascrrgrp.pc \
	DBC_mrascrrhis.pc \
	DBC_mrascrrmfo.pc \
	DBC_mrasevndef.pc \
	DBC_mraspmssec.pc \
	DBC_mraspmssts.pc \
	DBC_mraspotdef.pc \
	DBC_mraspothis.pc \
	DBC_mrasresdef.pc \
	DBC_mrasresdwh.pc \
	DBC_mrasresevn.pc \
	DBC_mrasreshis.pc \
	DBC_mrasreslab.pc \
	DBC_mrasreslth.pc \
	DBC_mrasresmfo.pc \
	DBC_mrasrsgdef.pc \
	DBC_mrasrsgres.pc \
	DBC_mrassrsdef.pc \
	DBC_mrassrsevn.pc \
	DBC_mrassrshis.pc \
	DBC_mrassrslot.pc \
	DBC_mrassrslth.pc \
	DBC_mrastevdef.pc \
	DBC_mrastoldef.pc \
	DBC_mrastoldft.pc \
	DBC_mrastolevn.pc \
	DBC_mrastolhis.pc \
	DBC_mrastoltye.pc \
	DBC_mrastolrel.pc \
	DBC_mrcplothis.pc \
	DBC_mrcplotpra.pc \
	DBC_mrcplotrcp.pc \
	DBC_mrcpmfodef.pc \
	DBC_mrcpprahis.pc \
	DBC_mrcppraver.pc \
	DBC_mrcprcpdef.pc \
	DBC_mrcprcpver.pc \
	DBC_mrcpslphis.pc \
	DBC_mrcpslthis.pc \
	DBC_mrcpsltpra.pc \
	DBC_mrcpsltrcp.pc \
	DBC_mrtddspdef.pc \
	DBC_mrtddspopr.pc \
	DBC_mrtddspres.pc \
	DBC_mrtdrulitm.pc \
	DBC_msecfundef.pc \
	DBC_msecgrpdef.pc \
	DBC_msecgrpfun.pc \
	DBC_mseclickey.pc \
	DBC_msecprvdef.pc \
	DBC_msecprvgrp.pc \
	DBC_msecprvusr.pc \
	DBC_msecusrdef.pc \
	DBC_msecusrext.pc \
	DBC_msecusrfun.pc \
	DBC_mspcalmhis.pc \
	DBC_mspccaldat.pc \
	DBC_mspcchtdef.pc \
	DBC_mspcchtmfo.pc \
	DBC_mspcchtset.pc \
	DBC_mspcchtunt.pc \
	DBC_mspcchtusr.pc \
	DBC_mspcdelhis.pc \
	DBC_mspcedcdat.pc \
	DBC_mspcoochis.pc \
	DBC_mspcprtdef.pc \
	DBC_mspcsetdef.pc \
	DBC_mspcspehis.pc \
	DBC_mspcsumdat.pc \
	DBC_mtmplothis.pc \
	DBC_mwipbakdef.pc \
	DBC_mwipbatdef.pc \
	DBC_mwipbathis.pc \
	DBC_mwipbatrel.pc \
	DBC_mwipbatrit.pc \
	DBC_mwipbatrsv.pc \
	DBC_mwipbatrul.pc \
	DBC_mwipcaldef.pc \
	DBC_mwipcoldef.pc \
	DBC_mwipcrrlot.pc \
	DBC_mwipcytdef.pc \
	DBC_mwipfaccmf.pc \
	DBC_mwipfacdef.pc \
	DBC_mwipfacshp.pc \
	DBC_mwipfatdef.pc \
	DBC_mwipfatact.pc \
	DBC_mwipfatsvc.pc \
	DBC_mwipfatcnd.pc \
	DBC_mwipflwdef.pc \
	DBC_mwipflwopr.pc \
	DBC_mwipgrddef.pc \
	DBC_mwipidgdef.pc \
	DBC_mwipidghis.pc \
	DBC_mwipidgrel.pc \
	DBC_mwipidgrul.pc \
	DBC_mwipidgskv.pc \
	DBC_mwiplotbat.pc \
	DBC_mwiplotbnm.pc \
	DBC_mwiplotbns.pc \
	DBC_mwiplotcmb.pc \
	DBC_mwiplotdel.pc \
	DBC_mwiplotdft.pc \
	DBC_mwiplothis.pc \
	DBC_mwiplothld.pc \
	DBC_mwiplotlos.pc \
	DBC_mwiplotlsm.pc \
	DBC_mwiplotmrg.pc \
	DBC_mwiplotrep.pc \
	DBC_mwiplotrwk.pc \
	DBC_mwiplotshp.pc \
	DBC_mwiplotspl.pc \
	DBC_mwiplotsts.pc \
	DBC_mwiplotyld.pc \
	DBC_mwipmatdef.pc \
	DBC_mwipmatflw.pc \
	DBC_mwipmfodef.pc \
	DBC_mwipmfopmt.pc \
	DBC_mwipmhdsts.pc \
	DBC_mwipoprdef.pc \
	DBC_mwipordsts.pc \
	DBC_mwipplndef.pc \
	DBC_mwipplnlot.pc \
	DBC_mwipqtmdef.pc \
	DBC_mwipqtmhis.pc \
	DBC_mwiprepdef.pc \
	DBC_mwiprmasts.pc \
	DBC_mwiprwkdef.pc \
	DBC_mwipsltdef.pc \
	DBC_mwipslthis.pc \
	DBC_mwipsltlos.pc \
	DBC_mwipsltsts.pc \
	DBC_mwipwrkord.pc \
	DBC_mwipylddef.pc \
	DBC_mwiprshlot.pc \
	DBC_qcmcore_join.pc \
	DBC_rascore_join.pc \
	DBC_rcpcore_join.pc \
	DBC_rtdcore_join.pc \
	DBC_seccore_join.pc \
	DBC_spccore_join.pc \
	DBC_wipcore_join.pc \
	DBC_mrasqrydef.pc \
	DBC_mrasshtdat.pc \
	DBC_mrasshtdef.pc \
	DBC_mrasshtrst.pc \
	DBC_mrasshtcat.pc \
	DBC_mrtdruldef.pc \
	DBC_mrtdevncon.pc \
	DBC_mrtdevnifh.pc \
	DBC_mrtdevnifs.pc \
	DBC_mrtdlotpdh.pc \
	DBC_mrtdlotpds.pc \
	DBC_mrtdrefopr.pc \
	DBC_mrtdresopr.pc \
	DBC_msecflxhdr.pc \
	DBC_mrascevdef.pc \
	DBC_msvmsvcdef.pc \
	DBC_msvmsvcmbr.pc \
	DBC_msvmmbrdef.pc \
	DBC_msvmdftver.pc \
	DBC_msvmkeyver.pc \
	DBC_msvmsvcurt.pc \
	DBC_mtmpreshis.pc \
	DBC_mtmpatrhis.pc \
	DBC_mtmpcrrhis.pc \
	DBC_mmsgbbshis.pc \
	DBC_mmsgbbsseq.pc \
	DBC_mmsgbbstxt.pc \
	DBC_mwiplotcvh.pc \
	DBC_mwiplotcvm.pc \
	DBC_mrascrrshs.pc \
	DBC_mwiplotmvh.pc \
	DBC_mwipsltmvh.pc \
	DBC_mwiplotqtm.pc \
	DBC_mbasglbdef.pc \
	DBC_mbasglbpmt.pc \
	DBC_mwiplotrds.pc \
	DBC_mwipsltrds.pc \
	DBC_mwipstpdef.pc \
	DBC_mwipstpmfo.pc \
	DBC_mwipstpsts.pc \
	DBC_mwipstphis.pc \
	DBC_medcchrfml.pc \
	DBC_mbasscrdef.pc \
	DBC_mwipoprinv.pc \
	DBC_mwiptollth.pc \
	DBC_mrastolrsh.pc \
	DBC_mbasscrrel.pc \
	DBC_mbasscrcnd.pc \
	DBC_mwipcrrlth.pc \
	DBC_mbasinqdef.pc \
	DBC_mbassqldef.pc \
	DBC_mwiplotlnr.pc \
	DBC_mgcmlagdat.pc \
	DBC_medccolche.pc \
	DBC_msvmerrlog.pc \
	DBC_msvmpfmlog.pc \
	DBC_mbasdoddef.pc \
	DBC_mbasdofdef.pc \
	DBC_mbasdotdef.pc \
	DBC_medcspmver.pc \
	DBC_mmsgbbsfil.pc \
	DBC_mqcgactdef.pc \
	DBC_mqcglotdef.pc \
	DBC_mqcglothis.pc \
	DBC_mqcgmforel.pc \
	DBC_mqcgsltdef.pc \
	DBC_mqcgslthis.pc \
	DBC_mqcgsmpdef.pc \
	DBC_mspmatrhis.pc \
	DBC_mspmatrsts.pc \
	DBC_mspmchrdsv.pc \
	DBC_mspmdocimg.pc \
	DBC_mspmrelchr.pc \
	DBC_mspmreldef.pc \
	DBC_mspmrelver.pc \
	DBC_mwipbindef.pc \
	DBC_mwipbingrd.pc \
	DBC_mwipbinhis.pc \
	DBC_mwipbinshs.pc \
	DBC_mwipbinhss.pc \
	DBC_mwipbinrel.pc \
	DBC_mwipbinunt.pc \
	DBC_mwipbinver.pc \
	DBC_mwipbinssh.pc \
	DBC_mwipbinfml.pc \
	DBC_mwiplydcod.pc \
	DBC_mwiplyddef.pc \
	DBC_mwippridef.pc \
	DBC_mwiptstpgm.pc \
	DBC_spmcore_join.pc \
	DBC_mwemactact.pc \
	DBC_mwemactcnd.pc \
	DBC_mwemactdef.pc \
	DBC_mwemevnhis.pc \
	DBC_mwemevnsts.pc \
	DBC_mwemevnsvh.pc \
	DBC_mwemevnsvl.pc \
	DBC_mwemprcdef.pc \
	DBC_mwemprcstp.pc \
	DBC_mwemprcusr.pc \
	DBC_mwemstpact.pc \
	DBC_mwemstpdef.pc \
	DBC_mwemstpsts.pc \
	DBC_mwemstsdef.pc \
	DBC_mwemtyedef.pc \
	DBC_mbaschklsq.pc \
	DBC_mbaschklsr.pc \
	DBC_mbaschklst.pc \
	DBC_mbaschkqry.pc \
	DBC_medcprtdef.pc \
	DBC_mbaschklsh.pc \
	DBC_mwipbinsph.pc \
	DBC_mbaschklsa.pc \
	DBC_mwipsltcvh.pc \
	DBC_mbatprcsts.pc \
	DBC_mbatprcdef.pc \
	DBC_mwipsltbos.pc \
	DBC_mbatprchis.pc \
	DBC_mwipidgscf.pc \
	DBC_mwiplotfqt.pc \
	DBC_mrtdrulext.pc \
	DBC_mspcoocext.pc \
	DBC_mspcrulext.pc \
	DBC_mpoplbldex.pc \
    DBC_mgcmtblhis.pc \
    DBC_mgcmdathis.pc \
    DBC_mtmppothis.pc 
	

OBJS := DBC_common_c.o


OBJS += ${PROCSOURCE:.pc=.o}

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

