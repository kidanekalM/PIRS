import { LineChart } from '@mui/x-charts/LineChart';
import { PieChart } from '@mui/x-charts/PieChart';
import { Card } from '@mui/material';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import { useEffect, useState } from 'react';

export default function Dashboard(){
  localStorage.setItem('appUserId', 'ukhui98');
  let companyId = localStorage.getItem('appUserId');
   let allReportsData= [
     { id: '0', value: 10, label: 'newReports' },
     { id: '1', value: 20, label: 'inProgress' },
     { id: '2', value: 5, label: 'submitted' },
     { id: '3', value: 17, label: 'approved' },
     { id: '4', value: 2, label: 'rejected' },
   ];

    return<>

          <Box component="main" display="flex" flexDirection="column" minHeight={"90vh"} gap={"1rem"} justifyContent="space-around" alignItems="center" sx={{ flexGrow: 1,pt: 3}}>
               <Box display={"flex"} flexDirection={"row"} gap="1rem" width={'50vw'} justifyContent={'space-between'}>
          <Card>
          <CardContent>
            <Typography variant="h5" component="div">
              Total Reports
            </Typography>
            <Typography variant="body2">
              200
            </Typography>
          </CardContent>
        </Card>
        <Card>
          <CardContent>
            <Typography variant="h5" component="div">
              Contractors
            </Typography>
            <Typography variant="body2">
              452
            </Typography>
          </CardContent>
        </Card>
        <Card>
          <CardContent>
            <Typography variant="h5" component="div">
              Response Time
            </Typography>
            <Typography variant="body2">
              10h
            </Typography>
          </CardContent>          
        </Card>
        </Box>
        
       <Box>
       <LineChart
          xAxis={[{ data: [1, 2, 3, 5, 8, 10] }]}
          series={[
            {
              data: [2, 5.5, 2, 8.5, 1.5, 5],
            },
          ]}
          width={500}
          height={300}
        />
        </Box> 

      </Box>
      <PieChart
      series={[
        {
          data:allReportsData,
          innerRadius: 30,
          outerRadius: 100,
          paddingAngle: 5,
          cornerRadius: 5,
          startAngle: -90,
        },
      ]
    }
      width={400}
      height={200}
    />
    
        </>
}; 