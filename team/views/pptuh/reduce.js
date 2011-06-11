function(keys,values,rereduce) {
  if(!rereduce) {
    pts = 0
    tuh = 0
    for (v in values) {
      pts += values[v][0]
      tuh += values[v][1]
    }
    return [pts/tuh,pts,tuh]
  } else {
    pts = 0
    tuh = 0
    for(v in values) {
      pts += values[v][1]
      tuh += values[v][2]
    }
    return [pts/tuh,pts,tuh]
  }
}