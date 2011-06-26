(keys,values,re) ->
  # results =  [gp,wins,losses,pts,ptsa,ppg,pct,mrg,tens,negs,tuh,ppth,bhrd,bpts,ppb]
  results = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
  
  for value in values
    for stat,s in results
      results[s] += value[s]
  
  #ppg
  results[5] = results[3] / results[0]
  
  #pct
  results[6] = results[1] / results[0]
  
  #mrg
  results[7] = (results[3] - results[4]) / results[0]
  
  #ppth
  results[11] = results[3] / results[10]
  
  #ppb
  results[14] = results[13] / results[12]
  
  results
