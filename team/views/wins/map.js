function(doc) {
		if(doc.type=="game"){
  if(doc.teamAscore > doc.teamBscore) {emit(doc.teamA,1)}else{emit(doc.teamB,1)}}
}