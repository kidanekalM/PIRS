import { LineChart } from '@mui/x-charts/LineChart';
import { Card } from '@mui/material';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';

export default function Dashboard(){
    return<>
          <Box component="main" display="flex"minHeight={"90vh"} gap={"1rem"} justifyContent="space-around" alignItems="center" sx={{ flexGrow: 1,pt: 3}}>
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
        <Box display={"flex"} flexDirection={"column"} gap="1rem">
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
      </Box>
        </>
}; 