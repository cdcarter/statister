function(doc) {
	if(doc.type=="game") {
		emit(doc.teamA,null)
		emit(doc.teamB,null)
	}
}