function(doc) {
  if (doc.type=="game") {
    emit([doc.round,doc._id], null);
  }
};