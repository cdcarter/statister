function(doc) {
  if (doc.type=="game") {
    emit([doc.round,doc.bracket,doc.room], [doc.teamA,doc.teamB]);
  }
};