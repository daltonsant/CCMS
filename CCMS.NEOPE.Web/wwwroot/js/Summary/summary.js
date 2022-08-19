(function ($) {

    function fnInitTracker(url,method) {
        fnGetCards(url, method, fnUpdateCards);

        setInterval(function () {
            fnGetCards(url, method, fnUpdateCards);
        }, 300000);
    }

    function fnGetCards(url, method) {
        $.ajax({
            url: url,
            method: method,
            async : true,
            success: function (data) {
                fnUpdateCards(data);
            }
        });
    }

    function fnUpdateCards(data) {
        let progress = document.getElementById("progressCard");
        let adherence = document.getElementById("adherenceCard");
        let conformity = document.getElementById("conformityCard");

        progress.innerHTML = (data["totalProgress"] * 100.0).toFixed(1) + "%";
        adherence.innerHTML = (data["totalAdherence"] * 100.0).toFixed(1) + "%";
        conformity.innerHTML = (data["totalConformity"] * 100.0).toFixed(1) + "%";
    }
    
    function fnGetPendenciesPerStepsChart(){
        let chartDom = document.getElementById('pendeciasPerEtapas');
        let myChart = echarts.init(chartDom);
        
        $.ajax({
            url: "",
            method: "POST",
            async : true,
            success: function (data) {
                let steps = data["steps"];
                let values = data["values"];
                let dataset = [];
                fnCreatePendenciesPerStepsChart(dataset, myChart);
            }
        });
        return myChart;
    }
    
    function fnCreatePendenciesPerStepsChart(dataset, myChart){
        let option = {
            color: ['#848f98', '#0063be', '#d9d9d9', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02]
            },
            yAxis: {
                type: 'category'
            },
            dataset: [{
                // Provide a set of data.
                source: [
                    ['Step', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    ['Planejamento', 1, 2, 3, 4],
                    ['TAC Equip. Interlig.', 2, 3, 4, 5],
                    ['TAF SPCS', 3, 4, 5, 6],
                    ['TAC SPCS', 4, 5, 6, 7],
                    ['Energização', 8, 7, 6, 5],
                    ['SAP', 6, 5, 4, 3]
                ]
            }],
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                }
            ]
        };

        option && myChart.setOption(option);
    }
    
    function fnGetPendenciesPerCategoryChart(){
        let chartDom = document.getElementById('pendeciasPerCategorias');
        let myChart = echarts.init(chartDom);

        $.ajax({
            url: "",
            method: "POST",
            async : true,
            success: function (data) {
                let steps = data["steps"];
                let values = data["values"];
                let dataset = [];
                fnCreatePendenciesPerCategoryChart(dataset, myChart);
            }
        });
        return myChart;
    }

    function fnCreatePendenciesPerCategoryChart(dataset, myChart){
        let option = {
            color: ['#848f98', '#0063be', '#d9d9d9', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02]
            },
            yAxis: {
                type: 'category'
            },
            dataset: [{
                // Provide a set of data.
                source: [
                    ['Category', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    ['Civil', 43.3, 85.8, 93.7, 20.0],
                    ['Eletromecânico', 83.1, 73.4, 55.1, 40.0],
                    ['Aterramento', 86.4, 65.2, 82.5, 200.0],
                    ['Projeto', 72.4, 53.9, 39.1, 100.0],
                    ['Painéis', 72.4, 53.9, 39.1, 100.0],
                    ['Equipamentos', 72.4, 53.9, 39.1, 100.0],
                    ['Interligações', 72.4, 53.9, 39.1, 100.0],
                    ['SPCS', 72.4, 53.9, 39.1, 100.0]
                ]
            }],
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                }
            ]
        };

        option && myChart.setOption(option);
    }
    
    function fnGetProgressPerCategoryChart(){
        let chartDom = document.getElementById('pendeciasPerCategorias');
        let myChart = echarts.init(chartDom);

        $.ajax({
            url: "",
            method: "POST",
            async : true,
            success: function (data) {
                let steps = data["steps"];
                let values = data["values"];
                let dataset = [];
                fnCreateProgressPerCategoryChart(dataset, myChart);
            }
        });
    }

    function fnCreateProgressPerCategoryChart(dataset, myChart){
        let option = {
            color: ['#848f98', '#0063be', '#d9d9d9', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02]
            },
            yAxis: {
                type: 'category'
            },
            dataset: [{
                // Provide a set of data.
                source: [
                    ['Category', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    ['Civil', 43.3, 85.8, 93.7, 20.0],
                    ['Eletromecânico', 83.1, 73.4, 55.1, 40.0],
                    ['Aterramento', 86.4, 65.2, 82.5, 200.0],
                    ['Projeto', 72.4, 53.9, 39.1, 100.0],
                    ['Painéis', 72.4, 53.9, 39.1, 100.0],
                    ['Equipamentos', 72.4, 53.9, 39.1, 100.0],
                    ['Interligações', 72.4, 53.9, 39.1, 100.0],
                    ['SPCS', 72.4, 53.9, 39.1, 100.0]
                ]
            }],
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                }
            ]
        };

        option && myChart.setOption(option);
    }

    function fnGetProgressPerStepChart(){
        let chartDom = document.getElementById('pendeciasPerCategorias');
        let myChart = echarts.init(chartDom);

        $.ajax({
            url: "",
            method: "POST",
            async : true,
            success: function (data) {
                let steps = data["steps"];
                let values = data["values"];
                let dataset = [];
                fnCreateProgressPerStepChart(dataset, myChart);
            }
        });
    }

    function fnCreateProgressPerStepChart(dataset, myChart){
        let option = {
            color: ['#848f98', '#0063be', '#d9d9d9', '#61a60e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    // Use axis to trigger tooltip
                    type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
                }
            },
            legend: {},
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'value',
                boundaryGap: [0, 0.02]
            },
            yAxis: {
                type: 'category'
            },
            dataset: [{
                // Provide a set of data.
                source: [
                    ['Category', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída'],
                    ['Civil', 43.3, 85.8, 93.7, 20.0],
                    ['Eletromecânico', 83.1, 73.4, 55.1, 40.0],
                    ['Aterramento', 86.4, 65.2, 82.5, 200.0],
                    ['Projeto', 72.4, 53.9, 39.1, 100.0],
                    ['Painéis', 72.4, 53.9, 39.1, 100.0],
                    ['Equipamentos', 72.4, 53.9, 39.1, 100.0],
                    ['Interligações', 72.4, 53.9, 39.1, 100.0],
                    ['SPCS', 72.4, 53.9, 39.1, 100.0]
                ]
            }],
            series: [
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                },
                {
                    type: 'bar',
                    stack: 'total',
                    label: {
                        show: true
                    }
                }
            ]
        };

        option && myChart.setOption(option);
    }
    
    $(document).ready(function () {
        fnInitTracker("/Home/GetProgress/", "POST");
        let charts = []
        let pendenciesPerStepsChart = fnGetPendenciesPerStepsChart();
        let pendenciesPerCategoryChart = fnGetPendenciesPerCategoryChart();
        //let progressPerCategoryChart = fnGetProgressPerCategoryChart();
        //let progressPerStepChart = fnGetProgressPerStepChart();
       
        $(window).resize(function() {
            pendenciesPerStepsChart.resize();
            pendenciesPerCategoryChart.resize();
        });
    });

} ( jQuery ))

/*
option = {
  color: ['#848f98', '#0063be', '#d9d9d9', '#61a60e'],
  title: {
      text: 'Pendencias Por Etapas'
  },
  tooltip: {
    trigger: 'axis',
    axisPointer: {
      // Use axis to trigger tooltip
      type: 'shadow' // 'shadow' as default; can also be 'line' or 'shadow'
    }
  },
  legend: {},
  grid: {
    left: '3%',
    right: '4%',
    bottom: '3%',
    containLabel: true
  },
  xAxis: {
    type: 'value'
  },
  yAxis: {
    type: 'category'
  },
  dataset: [{
    // Provide a set of data.
    source: [
      ['Step', 'Não iniciada', 'Em andamento', 'Em revisão', 'Concluída', 'score'],
      ['Planejamento', 43.3, 85.8, 93.7, 20.0, 90],
      ['TAC Equip. Interlig.', 83.1, 73.4, 55.1, 40.0, 90],
      ['TAF SPCS', 86.4, 65.2, 82.5, 200.0, 100],
      ['TAC SPCS', 72.4, 53.9, 39.1, 100.0, 99],
      ['Energização', 72.4, 53.9, 39.1, 100.0, 91],
      ['SAP', 72.4, 53.9, 39.1, 100.0, 90]
    ]
  },
  {
    transform : {
      type: 'sort',
       config: [
          // Sort by the two dimensions.
          { dimension: 5, order: 'asc' },
        ]
    }
  }],
  series: [
    { 
      type: 'bar', 
      stack: 'total',
      datasetIndex: 1,
      label: {
        show: true
      } 
    }, 
   { 
      type: 'bar', 
      stack: 'total',
      datasetIndex: 1,
      label: {
        show: true
      } 
    }, 
    { 
      type: 'bar', 
      stack: 'total',
      datasetIndex: 1,
      label: {
        show: true
      } 
    }, 
    { 
      type: 'bar', 
      stack: 'total',
      datasetIndex: 1,
      label: {
        show: true
      } 
    }
  ]
};
* */