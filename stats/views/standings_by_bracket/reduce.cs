(keys,values,re) ->

  results = {
    gp:0,w:0,l:0,pts:0,ptsa:0,
    tens:0,negs:0,tuh:0,
    bhrd:0, bpts:0
  }
  
  for value in values
    for stat of results
      results[stat] += value[stat]
  
  #ppg
  results.ppg = results.pts / results.gp
  
  #pct
  results.pct = results.w / results.gp
  
  #mrg
  results.mrg = (results.pts - results.ptsa) / results.gp
  
  #ppth
  results.ppth = results.pts / results.tuh
  
  #ppb
  results.ppb = results.bpts / results.bhrd
  
  results