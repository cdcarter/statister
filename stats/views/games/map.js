function(doc) {
  if (doc.type=="game") {
    emit(doc._id, doc);
  }
};