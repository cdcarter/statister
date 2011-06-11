function(doc) {
		if(doc.type=="game"){
  if (doc.teamAscore > doc.teamBscore) {
    emit(doc.teamA,1)
    emit(doc.teamB,0)
  }else{
    emit(doc.teamB,1)
    emit(doc.teamA,0)
  }}
}