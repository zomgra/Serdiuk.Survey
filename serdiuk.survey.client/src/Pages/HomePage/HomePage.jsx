import { Box, Grid, Typography } from '@mui/material'
import React, { useState } from 'react'
import SurveyView from '../../Components/SurveyView/SurveyView';
import SurveyPage from '../SurveyPage/SurveyPage';
import PageNavigation from '../../Components/PageNavigation/PageNavigation';

const HomePage = ({ surveys,pageNumber,setPageNumber }) => {

    const [currentSurvley, setCurrentSurvley] = useState();

    if (!surveys) {
        return (<>
            <Typography >
                Surveys not found
            </Typography>
        </>)
    }
    
    if(currentSurvley){
        return(
            <Box>
                <SurveyPage survey={currentSurvley}/>
            </Box>
        )
    }
    return (
        <Grid container spacing={3}>
            {surveys.map(s =>
                <SurveyView key={s.id} survey={s} toSurvey={()=>setCurrentSurvley(s)} />
            )}
                  <PageNavigation onPageChange={setPageNumber} page = {pageNumber}/>
        </Grid>
    )
}

export default HomePage