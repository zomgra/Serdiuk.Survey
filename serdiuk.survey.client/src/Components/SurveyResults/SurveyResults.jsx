import { useState, useEffect, useRef } from 'react';
import React from 'react';
import { Box, Typography, Grid } from '@mui/material';
import Chart from 'chart.js/auto';

function SurveyResults({ survey }) {
  const [expanded, setExpanded] = useState(false);
  const chartRefs = useRef([]);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  useEffect(() => {
    chartRefs.current.forEach((chartRef, index) => {
      const question = survey.questions[index];
      const chartData = question.answers.map((answer) => answer.count);

      new Chart(chartRef, {
        type: 'bar',
        data: {
          labels: question.answers.map((answer) => answer.value),
          datasets: [
            {
              label: 'Answers',
              data: chartData,
              backgroundColor: '#8884d8',
              borderColor: '#8884d8',
              borderWidth: 1,
            },
          ],
        },
        options: {
          scales: {
            y: {
              beginAtZero: true,
            },
          },
        },
      });
    });
  }, [survey.questions]);

  return (
    <Box sx={{ p: 2 }}>
      <Typography variant="h5">Survey Results</Typography>
      <Grid container spacing={2} sx={{ mt: 2 }}>
        {survey.questions.map((question, index) => (
          <React.Fragment key={index}>
            <Grid item xs={6} sm={6} md={6} lg={6} xl={6}>
              <Box sx={{ mb: 2 }}>
                <Typography variant="h6">{question.text}</Typography>
                <canvas
                  ref={(el) => (chartRefs.current[index] = el)}
                  style={{ width: '80%', height: 'auto' }}
                />
              </Box>
            </Grid>
          </React.Fragment>
        ))}
      </Grid>
    </Box>
  );
}

export default SurveyResults;