function(doc) {
		if(doc.type=="game"){
  emit(doc.teamB,1)
  emit(doc.teamA,1)}
}