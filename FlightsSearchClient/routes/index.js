var express = require('express');
var router = express.Router();


router.get('/flights-search', function(req, res, next) {
  res.render('flights',{title:'express app'})
});


module.exports = router;
