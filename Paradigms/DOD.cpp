#include <vector>
#include <iostream>
#include <algorithm>

// Traditional OOP approach (for comparison)
struct ParticleOOP
{
  float x, y, z;
  float vx, vy, vz;
  
  void update(float dt)
  {
    x += vx * dt;
    y += vy * dt;
    z += vz * dt;
  }
};

// DOD approach
struct ParticleSystem
{
  std::vector<float> x, y, z;
  std::vector<float> vx, vy, vz;

  void add_particle(float px, float py, float pz, float pvx, float pvy, float pvz)
  {
    x.push_back(px);
    y.push_back(py);
    z.push_back(pz);
    vx.push_back(pvx);
    vy.push_back(pvy);
    vz.push_back(pvz);
  }

  void update(float dt)
  {
    for (size_t i = 0; i < x.size(); ++i)
    {
      x[i] += vx[i] * dt;
      y[i] += vy[i] * dt;
      z[i] += vz[i] * dt;
    }
  }
};

int main()
{
  const int PARTICLE_COUNT = 1000000;
  const float DT = 0.1f;

  // DOD approach
  ParticleSystem particles;
  for (int i = 0; i < PARTICLE_COUNT; ++i)
  {
    particles.add_particle(0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f);
  }

  // Update particles
  particles.update(DT);

  // Print first particle position
  std::cout << "First particle position: "
            << particles.x[0] << ", "
            << particles.y[0] << ", "
            << particles.z[0] << std::endl;

  return 0;
}