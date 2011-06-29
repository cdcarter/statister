(keys,values,rereduce) -> 
  statline = {
    gp:0, tens:0, negs:0, tuh:0, pts:0
  }
  
  for value in values
    for stat of statline
      statline[stat] += value[stat]
  
  # ppg
  statline.ppg = statline.pts / statline.gp
  
  # ppth
  statline.ppth = statline.pts / statline.tuh
  
  statline