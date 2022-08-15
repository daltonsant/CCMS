/*!
 * Admin v1.0.2
 * Materialize theme
 * http://materializecss.com/themes.html
 * Personal Use License
 * by Alan Chang
 */

/********************
 * Helper Functions *
 ********************/
var debounce = function (fn, duration) {
  var timeout;
  return function () {
    var args = Array.prototype.slice.call(arguments),
        ctx = this;

    clearTimeout(timeout);
    timeout = setTimeout(function () {
      fn.apply(ctx, args);
    }, duration);
  };
};

var chartExists = function(cardChart) {
  var exists = false;
  for (var i in Chart.instances) {
    chart = Chart.instances[i];
    if (cardChart.is(chart.canvas)) {
      exists = true;
      break;
    }
  }

  if (exists) {
    return chart;
  } else {
    return false;
  }
}

function randomNumber(min, max) {
  return Math.random() * (max - min) + min;
}

function getRandomBarNoTime(lastClose) {
  var open = randomNumber(lastClose * .95, lastClose * 1.05);
  var close = randomNumber(open * .95, open * 1.05);
  var high = randomNumber(Math.max(open, close), Math.max(open, close) * 1.1);
  var low = randomNumber(Math.min(open, close) * .9, Math.min(open, close));
  return {
    o: open,
    h: high,
    l: low,
    c: close,
  };
}

function randomBar(date, lastClose) {
  var bar = getRandomBarNoTime(lastClose);
  bar.t = date.valueOf();
  return bar;
}

function getRandomData(date, count) {
  var dateFormat = 'MMMM DD YYYY';
  var date = moment(date, dateFormat);
  var data = [randomBar(date, 30)];
  while (data.length < count) {
    date = date.clone().add(1, 'd');
    if (date.isoWeekday() <= 5) {
      data.push(randomBar(date, data[data.length - 1].c));
    }
  }
  return data;
}

/* End Helper Functions */



(function ($) {
  $(document).ready(function(){


    /********************
     * Materialize Init *
     ********************/

    $('.card-toolbar-actions .dropdown-trigger').dropdown({
      constrainWidth: false,
    });

    /* End Materialize Init */



    
    
  });
}( jQuery ));
