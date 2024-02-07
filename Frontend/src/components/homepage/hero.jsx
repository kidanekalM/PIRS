import { Link } from 'react-router-dom';
import '../../component_styles/hero.css';
const Hero = () => {
    return ( 
        <div>
          <div className="row">
          <section className='light-image col-6'>
        <div className="heroInner justify-content-center my-5">
            <span>
              <h1 className='display-6 my-5'>Report, Gain Ratings and Expect Support in a Short Time</h1>
              <Link to="/signupasuser">
              <p className="btn btn-dark">
                Report Now
              </p>
              </Link>
            </span>
          </div>
        </section>
          <section className="light-hero col-6">
        </section>
          </div>
      </div>
     );
}
 
export default Hero;