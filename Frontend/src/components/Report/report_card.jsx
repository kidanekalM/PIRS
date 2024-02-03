import { Card, CardContent, Typography, IconButton, Tooltip, LinearProgress, Box, Grid } from '@mui/material';
import { Edit, Delete, ThumbUp } from '@mui/icons-material';

const ReportCard = ({ report, role }) => {
  if (!report) {
    return <div>No report data</div>;
  }

  return (
    <Card>
      <Grid container>
        <Grid item xs={4}>
          <img src={report.pictures[0].url} alt="Demo" loading="lazy" style={{ width: '100%', height: 'auto' }} />
        </Grid>
        <Grid item xs={8}>
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {report.Title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {report.Description}
            </Typography>
            {role === 'Contractor' && (
              <Typography variant="body2" color="text.secondary">
                Award Amount: ${report.awardAmount}
              </Typography>
            )}
            <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', mt: 2 }}>
              <Box sx={{ display: 'flex', alignItems: 'center' }}>
                <IconButton>
                  <ThumbUp />
                </IconButton>
                <Typography variant="body2" color="text.secondary">
                  {report.upvotes.length}
                </Typography>
              </Box>
              <Box sx={{ display: 'flex', alignItems: 'center' }}>
                <IconButton>
                  <Edit />
                </IconButton>
                <IconButton>
                  <Delete />
                </IconButton>
              </Box>
            </Box>
          </CardContent>
        </Grid>
      </Grid>
      <LinearProgress variant="determinate" value={report.status} />
    </Card>
  );
};

export default ReportCard;