(keys,values,re) ->
  round = {pts: 0, tpts:0, tuh: 0, bpts: 0, bhrd: 0, gp: 0}
  
  for value in values
    for stat of round
      round[stat] += value[stat]
  
  round.ppb = round.bpts/round.bhrd
  round.tuppth = round.tpts/round.tuh
  round.ppg = round.pts/round.gp
  
  round