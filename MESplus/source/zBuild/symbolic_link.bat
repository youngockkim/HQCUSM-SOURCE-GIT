#!/bin/bash

list=`ls ../../lib/lib*.so.*`

for lib in $list
do
  source=${lib##.*/}
  destination=${source/.so.*/.so}
  ln -sf $MESplus_HOME/lib/$source $MESplus_HOME/lib/$destination
  echo "ln -sf $MESplus_HOME/lib/$source $MESplus_HOME/lib/$destination"
done

exit 0
